// See https://aka.ms/new-console-template for more information
using System.Text;
using Domain.AppEntities;
using Domain.Dtos;
using Newtonsoft.Json;
using OnlineMuhasebeServer.RabbitMQ.Context;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Domain.CompanyEntities;
using Domain.AppEntities;
using Domain.Dtos;
using Persistence.Context;
using OnlineMuhasebeServer.RabbitMQ.Context;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;

Console.WriteLine("Read Queue working");
var factory = new ConnectionFactory();
factory.Uri = new Uri("amqp://guest:guest@localhost:5672");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.QueueDeclare("Reports", true, false, false);

var consumer = new EventingBasicConsumer(channel);
channel.BasicConsume("Reports", true, consumer);

consumer.Received += Consumer_Received;

//ReadQueue();
Console.ReadLine();



static void ReadQueue()
{
    Console.WriteLine("Read Queue working");
    var factory = new ConnectionFactory();
    factory.Uri = new Uri("amqp://guest:guest@localhost:5672");

    using var connection = factory.CreateConnection();

    var channel = connection.CreateModel();

    channel.QueueDeclare("Reports",true,false,false);

    var consumer = new EventingBasicConsumer(channel);
    channel.BasicConsume("Reports", true, consumer);

    consumer.Received += Consumer_Received;

}

static void Consumer_Received(object? sender, BasicDeliverEventArgs e)
{
    string reportString = Encoding.UTF8.GetString(e.Body.ToArray());
    ReportDto reportDto = JsonConvert.DeserializeObject<ReportDto>(reportString);
    if(reportDto.Name == "Hesap Plani")
    {
        CreateUCAFExcel(reportDto);
    }
}
static void CreateUCAFExcel(ReportDto reportDto)
{
    Console.WriteLine("Create UCaf icindeyiz");
    OnlineMuhasebeServer.RabbitMQ.Context.AppDbContext appDbContext = new();
    Company company = appDbContext.Set<Company>().Find(reportDto.CompanyId);

    CompanyDbContext _companyDbContext = new(company);
    IList<UCAF> ucafs = _companyDbContext.Set<UCAF>().OrderBy(p => p.Code).ToList();

    string fileName = "";
    using (var workbook = new XLWorkbook())
    {
        var ws = workbook.Worksheets.Add("Hesap Plani");
        ws.Range("A1").Value = company.Name + " Hesap Plani";
        ws.Range("A3").Value = "Kod";
        ws.Range("B3").Value = "Tip";
        ws.Range("C3").Value = "Adı";
        ws.Range("A1:C1").Merge();

        
        ws.Range("A1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        ws.Range("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


        int rowCount = 4;
        for (int i = 0; i < ucafs.Count; i++)
        {
            ws.Range("A" + rowCount).Value = ucafs[i].Code;
            ws.Range("B" + rowCount).Value = ucafs[i].Type;
            ws.Range("C" + rowCount).Value = ucafs[i].Name;
            rowCount++;

            if (ucafs[i].Type == "A")            
                ws.Range($"A{rowCount}:C${rowCount}").Style.Font.FontColor = XLColor.Red;
            else if (ucafs[i].Type == "G")
                ws.Range($"A{rowCount}:C${rowCount}").Style.Font.FontColor = XLColor.Blue;
        }

        ws.Style.Font.Bold = true;
        ws.Columns("A:C").AdjustToContents();


   
        int lastRow = ws.LastRowUsed().RowNumber();
           ws.Range($"A3:C{lastRow}").Style.Border.TopBorder = XLBorderStyleValues.Thin;
        ws.Range($"A3:C{lastRow}").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        ws.Range($"A3:C{lastRow}").Style.Border.RightBorder = XLBorderStyleValues.Thin;
        ws.Range($"A3:C{lastRow}").Style.Border.LeftBorder = XLBorderStyleValues.Thin;   
        fileName = ($"HesapPlan{company.Id}.{DateTime.Now}.xlsx").Replace(":",".");
        string filePath = $"/Users/alperalanyali/Desktop/OnlineMuhasebeClient/src/assets/reports/{fileName}";
        workbook.SaveAs(filePath);
    }
    Report report = _companyDbContext.Set<Report>().Find(reportDto.Id);
    report.FileUrl = fileName;
    report.Status = true;
    report.UpdatedDate = DateTime.Now;

    _companyDbContext.Update(report);
    _companyDbContext.SaveChanges();

    Console.WriteLine("Excel basarili ile olusturuldu");
}
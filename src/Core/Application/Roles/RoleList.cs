using System;
using Domain.AppEntities;
using Domain.AppEntities.Identity;

namespace Application.Roles
{
	public sealed class RoleList
	{

		public static List<AppRole> GetStaticRoles()
		{
            #region UCAF
            List<AppRole> roles = new List<AppRole>
            {
                new AppRole(
                title: UCAF,
                code: UCAFCreateCode,
                name: UCAFCreateName
                ),

                new AppRole(
                title: UCAF,
                code: UCAFUpdateCode,
                name: UCAFUpdateName
                ),

                new AppRole(
                title: UCAF,
                code: UCAFDeleteCode,
                name: UCAFDeleteName
                ),

                new AppRole(
                title: UCAF,
                code: UCAFReadCode,
                name: UCAFReadName
                )
            };
            #endregion
            return roles;
		}


        public static List<MainRole> GetStaticMainRole()
        {
            List<MainRole> mainRoles = new List<MainRole>
            {
                new MainRole(
                    "Admin",
                    null,
                    true                      
                    ),
                   new MainRole(
                    "Yonetici",
                    null,
                    true
                    ),
                      new MainRole(
                    "Kullanıcı",
                    null,
                    true
                    ),

            };

            return mainRoles;

        }
        #region Role Title Name
        public static string UCAF = "Hesap Planı";

        #endregion
        #region Role Code and Names
        public static string UCAFCreateCode = "UCAF.Create";
        public static string UCAFCreateName= "Hesap Planı Kayıt";

        public static string UCAFUpdateCode = "UCAF.Update";
        public static string UCAFUpdateName = "Hesap Planı Güncelle";

        public static string UCAFDeleteCode = "UCAF.Delete";
        public static string UCAFDeleteName = "Hesap Planı Sil";

        public static string UCAFReadCode = "UCAF.Read";
        public static string UCAFReadName = "Hesap Planı Okuma";
        #endregion


    }


}


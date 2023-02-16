using System;
using Domain.Abstractions;

namespace Domain.AppEntities
{
	public class NavigationItem:Entity
	{
		public NavigationItem()
		{

		}
		public NavigationItem(string navigationName,string navigationPath,string topNavigationId,int priority)
		{
			Id = Guid.NewGuid().ToString();
			NavigationName = navigationName;
			NavigationPath = navigationPath;
			TopNavigationId = topNavigationId;
			Priority = priority;

        }
		public string NavigationName { get; set; }
		public string NavigationPath { get; set; }
		public string TopNavigationId { get; set; }
        public int Priority { get; set; }

    }
}


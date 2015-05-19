using System;
using System.Collections.Generic;
using AutoMapper;

namespace AutoMapperBug
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Mapper.CreateMap<UserDataModel, UserDomain>()
				.ConstructUsing(x => new UserDomain(x.UserName, x.Phone))
				.IgnoreAllPropertiesWithAnInaccessibleSetter();

			var databaseUsers = GetDatabaseUser();

			var domainUsers = Mapper.Map<List<UserDomain>>(databaseUsers);

			domainUsers.ForEach(x => Console.WriteLine("name: {0}, phone: {1}, password: {2}", x.Name, x.Phone, x.Password));

			Console.ReadLine();
		}

		private static List<UserDataModel> GetDatabaseUser()
		{
			return new List<UserDataModel>
					{
						new UserDataModel {UserName = "test user", Phone = "123", Password = "hidden"},
						new UserDataModel {UserName = "admin", Phone = "911", Password = "secret"}
					};
		}
	}
}
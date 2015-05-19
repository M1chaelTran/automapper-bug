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
				.ConstructUsing(x => new UserDomain(x.UserName, x.Phone));

			var databaseUsers = new List<UserDataModel>
								{
									new UserDataModel {UserName = "test user", Phone = "123", Password = "hidden"},
									new UserDataModel {UserName = "admin", Phone = "911", Password = "secret"}
								};

			var domainUsers = Mapper.Map<List<UserDomain>>(databaseUsers);

			domainUsers.ForEach(x => Console.WriteLine("name: {0}, phone: {1}, password: {2}", x.Name, x.Phone, x.Password));

			Console.ReadLine();
		}
	}

	public class UserDomain
	{
		public UserDomain(string name, string phone)
		{
			Name = name == "admin" ? "You're an admin" : name;
			Phone = phone == "911" ? "000" : phone;
		}

		public string Name { get; private set; }
		public string Phone { get; private set; }
		public string Password { get; private set; }
	}

	public class UserDataModel
	{
		public string UserName { get; set; }
		public string Phone { get; set; }
		public string Password { get; set; }
	}
}
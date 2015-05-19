namespace AutoMapperBug
{
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
}
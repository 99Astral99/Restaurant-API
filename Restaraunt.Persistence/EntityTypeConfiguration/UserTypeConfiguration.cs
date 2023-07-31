using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaraunt.Domain.Entities.Identity;

namespace Restaraunt.Persistence.EntityTypeConfiguration
{
	public class UserTypeConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasOne(u => u.Cart)
		   .WithOne(x => x.User)
		   .HasPrincipalKey<User>(x => x.Id)
		   .OnDelete(DeleteBehavior.Cascade);
			#region UserSeed
			//var user1 = new User()
			//{
			//	Id = new Guid("A4A67768-DEDA-43BC-A545-A67D1ABDA650"),
			//	Email = "customer@gmail.com",
			//	EmailConfirmed = true,
			//	UserName = "Customer111",
			//	NormalizedUserName = "CUSTOMER111",
			//	AccessFailedCount = 0,
			//};

			//var user2 = new User()
			//{
			//	Id = new Guid("12539B7B-B1E6-4A04-BE98-6921487CAEF3"),
			//	Email = "admin@gmail.com",
			//	EmailConfirmed = true,
			//	UserName = "Admin111",
			//	NormalizedUserName = "ADMIN111",
			//	//AccessFailedCount = 0,
			//};

			//PasswordHasher<User> ph = new PasswordHasher<User>();
			//user1.PasswordHash = ph.HashPassword(user1, "DefaultCustomerPassword111$");
			//user2.PasswordHash = ph.HashPassword(user2, "DefaultAdminPassword111$");

			//builder.HasData(user1);
			//builder.HasData(user2);

			//builder.HasData(
			//	new IdentityRole<Guid>
			//	{
			//		Id = new Guid("76BA16A2-158A-46EF-89E7-24E8684AAB20"),
			//		Name = "Customer",
			//		NormalizedName = "CUSTOMER",
			//		ConcurrencyStamp = "76BA16A2-158A-46EF-89E7-24E8684AAB20"
			//	});

			//builder.HasData(
			//	new IdentityRole<Guid>
			//	{
			//		Id = new Guid("417EA524-3412-4929-8533-74354E887CC5"),
			//		Name = "Admin",
			//		NormalizedName = "ADMIN",
			//		ConcurrencyStamp = "417EA524-3412-4929-8533-74354E887CC5"
			//	});

			//builder.HasData(
			//	new IdentityUserRole<Guid>
			//	{
			//		RoleId = new Guid("76BA16A2-158A-46EF-89E7-24E8684AAB20"),
			//		UserId = new Guid("A4A67768-DEDA-43BC-A545-A67D1ABDA650")
			//	});

			//builder.HasData(
			//	new IdentityUserRole<Guid>
			//	{
			//		RoleId = new Guid("417EA524-3412-4929-8533-74354E887CC5"),
			//		UserId = new Guid("12539B7B-B1E6-4A04-BE98-6921487CAEF3")
			//	});
			#endregion
		}
	}
}

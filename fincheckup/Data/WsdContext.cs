//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using fincheckup.Models.Account;
//using fincheckup.Models.Definition;
//using fincheckup.Models.Organization;
//using fincheckup.Models.Projects;
//using fincheckup.Models.Request;

//namespace fincheckup.Data
//{
//	public class WsdContext : DbContext
//	{
//		public DbSet<AppUser> AppUsers { get; set; }

//		public DbSet<Category> Categories { get; set; }
//		public DbSet<Status> Statuses { get; set; }

//		public DbSet<Department> Departments { get; set; }

//		public DbSet<ProjectRole> ProjectRoles { get; set; }
//		public DbSet<Requests> Requests { get; set; }

//		public WsdContext(DbContextOptions<WsdContext> options) : base(options) { }

//		protected override void OnModelCreating(ModelBuilder modelBuilder)
//		{
//			base.OnModelCreating(modelBuilder);

//			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
//			{
//				relationship.DeleteBehavior = DeleteBehavior.Restrict;
//			}
//		}
//	}
//}

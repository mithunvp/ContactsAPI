using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ContactsApi.Contexts;

namespace ContactsApi.Migrations
{
    [DbContext(typeof(ContactsContext))]
    [Migration("20161008110835_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContactsApi.Models.Contacts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AnniversaryDate");

                    b.Property<string>("Company");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsFamilyMember");

                    b.Property<string>("JobTitle");

                    b.Property<string>("LastName");

                    b.Property<string>("MobilePhone");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });
        }
    }
}

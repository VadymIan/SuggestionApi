// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuggestionApplication.Persistence;

#nullable disable

namespace SuggestionApplication.Persistence.Migrations
{
    [DbContext(typeof(SuggestionApplicationDbContext))]
    [Migration("20220518082642_AddEmailConfirmationColumn")]
    partial class AddEmailConfirmationColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SuggestionApplication.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SuggestionApplication.Domain.Entities.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("SuggestionApplication.Domain.Entities.Suggestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ApprovedForRelease")
                        .HasColumnType("bit");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<Guid?>("Author_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Categoty_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OwnerNotes")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Rejected")
                        .HasColumnType("bit");

                    b.Property<Guid?>("Status_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("Author_Id");

                    b.HasIndex("Categoty_Id");

                    b.HasIndex("Status_Id");

                    b.ToTable("Suggestions");
                });

            modelBuilder.Entity("SuggestionApplication.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailIsConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SuggestionUser", b =>
                {
                    b.Property<Guid>("UserVotesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VotedOnSuggestionsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserVotesId", "VotedOnSuggestionsId");

                    b.HasIndex("VotedOnSuggestionsId");

                    b.ToTable("SuggestionUser");
                });

            modelBuilder.Entity("SuggestionApplication.Domain.Entities.Suggestion", b =>
                {
                    b.HasOne("SuggestionApplication.Domain.Entities.User", "Author")
                        .WithMany("AuthoredSuggestions")
                        .HasForeignKey("Author_Id");

                    b.HasOne("SuggestionApplication.Domain.Entities.Category", "Categoty")
                        .WithMany()
                        .HasForeignKey("Categoty_Id");

                    b.HasOne("SuggestionApplication.Domain.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("Status_Id");

                    b.Navigation("Author");

                    b.Navigation("Categoty");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("SuggestionUser", b =>
                {
                    b.HasOne("SuggestionApplication.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserVotesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuggestionApplication.Domain.Entities.Suggestion", null)
                        .WithMany()
                        .HasForeignKey("VotedOnSuggestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SuggestionApplication.Domain.Entities.User", b =>
                {
                    b.Navigation("AuthoredSuggestions");
                });
#pragma warning restore 612, 618
        }
    }
}

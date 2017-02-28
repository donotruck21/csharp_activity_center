using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using activityCenter.Models;

namespace activityCenter.Migrations
{
    [DbContext(typeof(activityCenterContext))]
    partial class activityCenterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("activityCenter.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActivityDate");

                    b.Property<DateTime>("ActivityTime");

                    b.Property<string>("Description");

                    b.Property<string>("DurationUnit");

                    b.Property<int>("DurationVal");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("ActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("activityCenter.Models.JoinedUser", b =>
                {
                    b.Property<int>("JoinedUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Updatedat");

                    b.Property<int>("UserId");

                    b.HasKey("JoinedUserId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("JoinedUsers");
                });

            modelBuilder.Entity("activityCenter.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("activityCenter.Models.Activity", b =>
                {
                    b.HasOne("activityCenter.Models.User", "User")
                        .WithMany("Activities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("activityCenter.Models.JoinedUser", b =>
                {
                    b.HasOne("activityCenter.Models.Activity", "Activity")
                        .WithMany("JoinedUsers")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("activityCenter.Models.User", "User")
                        .WithMany("JoinedUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

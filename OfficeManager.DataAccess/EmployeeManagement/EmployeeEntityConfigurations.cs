using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeManager.DataAccess.EmployeeManagement
{
    public class EmployeeEntityConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("om_tbl_employees");

            builder.HasKey(pr => pr.Id);
            builder.Property(pr => pr.Id).HasColumnName("cln_id");
            builder.Property(pr => pr.Firstname).HasColumnName("cln_firstname").IsRequired();
            builder.Property(pr => pr.Lastname).HasColumnName("cln_lastname").IsRequired();
            builder.Property(pr => pr.Birthdate).HasColumnName("cln_birthdate").IsRequired();
            builder.Property(pr => pr.PassportSerialNumber).HasColumnName("cln_passport_serial_number").IsRequired();
            builder.Property(pr => pr.PassportNumber).HasColumnName("cln_passport_number").IsRequired();
            builder.Property(pr => pr.RegistrationCity).HasColumnName("cln_reg_city").IsRequired();
            builder.Property(pr => pr.City).HasColumnName("cln_city").IsRequired();
            builder.Property(pr => pr.Adderss).HasColumnName("cln_address").IsRequired();
            builder.Property(pr => pr.MobilePhone).HasColumnName("cln_address").IsRequired();

            builder.Property(pr => pr.Created).HasColumnName("cln_created").IsRequired();
            builder.Property(pr => pr.Updated).HasColumnName("cln_updated").IsRequired();
            builder.Property(pr => pr.IsDeleted).HasColumnName("cln_is_deleted").IsRequired();


        }
    }
}

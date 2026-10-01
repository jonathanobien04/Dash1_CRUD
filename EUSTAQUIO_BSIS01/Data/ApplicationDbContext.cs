﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

using MVC_CRUD.Models;

 

namespace MVC_CRUD.Data;

 

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)

{

    public DbSet<Customer> Customers { get; set; }

}
dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=bsu_map;" Npgsql.EntityFrameworkCore.PostgreSQL -o Models -f --project ../BSU.Map.Api/BSU.Map.DAL

mv ../BSU.Map.Api/BSU.Map.DAL/Models/bsu_mapContext.cs ../BSU.Map.Api/BSU.Map.DAL/ApplicationDbContext.cs

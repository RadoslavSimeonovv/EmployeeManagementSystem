using EmployeeManagementSystem.DataAccess.Entities;
using EmployeeManagementSystem.DataAccess.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.API.Seeder
{
    public static class Seeder
    {
        public static void SeedData(DbContext context)
        {
            var employees = GetEmployees();

            var roles = GetRoles();

            var employeeRoles = GetEmployeeRoles();

            var shifts = GetShifts();

            var employeesToAdd = employees.Except(context.Set<Employee>().AsEnumerable()).ToList();

            var rolesToAdd = roles.Except(context.Set<Role>().AsEnumerable()).ToList();

            var shiftsToAdd = shifts.Except(context.Set<Shift>().AsEnumerable()).ToList();

            var employeeRolesToAdd = employeeRoles.Except(context.Set<EmployeeRoles>().AsEnumerable()).ToList();

            if (!context.Set<Employee>().AsEnumerable().Any())
            {
                context.Set<Employee>().AddRange(employeesToAdd);
            }
            if (!context.Set<Role>().AsEnumerable().Any())
            {
                context.Set<Role>().AddRange(rolesToAdd);
            }
            if (!context.Set<EmployeeRoles>().AsEnumerable().Any())
            {
                context.Set<EmployeeRoles>().AddRange(employeeRolesToAdd);
            }
            if (!context.Set<Shift>().AsEnumerable().Any())
            {
                context.Set<Shift>().AddRange(shiftsToAdd);
            }

            context.SaveChanges();
        }

        public async static void SeedDataAsync(DbContext context, CancellationToken cancellationToken)
        {
            var employees = GetEmployees();

            var roles = GetRoles();

            var employeeRoles = GetEmployeeRoles();

            var shifts = GetShifts();

            var employeesToAdd = employees.Except(context.Set<Employee>().AsEnumerable()).ToList();

            var rolesToAdd = roles.Except(context.Set<Role>().AsEnumerable()).ToList();

            var shiftsToAdd = shifts.Except(context.Set<Shift>().AsEnumerable()).ToList();

            var employeeRolesToAdd = employeeRoles.Except(context.Set<EmployeeRoles>().AsEnumerable()).ToList();

            if (!context.Set<Employee>().AsEnumerable().Any())
            {
                context.Set<Employee>().AddRange(employeesToAdd);
            }
            if (!context.Set<Role>().AsEnumerable().Any())
            {
                context.Set<Role>().AddRange(rolesToAdd);
            }
            if (!context.Set<EmployeeRoles>().AsEnumerable().Any())
            {
                context.Set<EmployeeRoles>().AddRange(employeeRolesToAdd);
            }
            if (!context.Set<Shift>().AsEnumerable().Any())
            {
                context.Set<Shift>().AddRange(shiftsToAdd);
            }

            await context.SaveChangesAsync(cancellationToken);
        }

        public static IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    Id = new Guid("24f9aeb4-0f2d-49f9-a7a8-7e61ab56b865"),
                    Name = "Ollie Austin"
                },
                new Employee
                {
                    Id = new Guid("19ba6582-01cf-42bf-b5d8-133a7f6dcc49"),
                    Name = "Rylee Mcgee"
                },
                new Employee
                {
                    Id = new Guid("f3a98a68-21c6-4cfb-95f3-f1be093a12db"),
                    Name = "Sam Owen"
                },
                new Employee
                {
                    Id = new Guid("8e878e79-f71c-4ea9-a3ec-d781d96c69f7"),
                    Name = "Jack Marshall"
                },
                new Employee
                {

                    Id = new Guid("7dfd6bcc-19c7-4d4e-b495-d44234596be8"),
                    Name = "Josh Gibson"
                }
            };
        }

        public static IEnumerable<Role> GetRoles()
        {
            return new List<Role>()
            {
                new Role
                {
                    Id = new Guid("d44e6ed1-2c0a-4825-b242-da90232a005b"),
                    Name = nameof(EmployeeRole.Cleaner)
                },
                new Role
                {
                    Id = new Guid("19e94a6d-d0c8-4e72-947a-9522c470f073"),
                    Name = nameof(EmployeeRole.Waiter)
                },
                new Role
                {
                    Id = new Guid("76bb955d-3a55-4609-b960-2662a0dbff59"),
                    Name = nameof(EmployeeRole.Barman)
                },
                new Role
                {
                    Id = new Guid("73483115-6945-4dcf-bc7e-c8834486c94b"),
                    Name = nameof(EmployeeRole.Chef)
                }
            };
        }

        public static IEnumerable<EmployeeRoles> GetEmployeeRoles()
        {
            return new List<EmployeeRoles>()
            {
                new EmployeeRoles
                {
                    EmployeeId = new Guid("24f9aeb4-0f2d-49f9-a7a8-7e61ab56b865"),
                    RoleId = new Guid("d44e6ed1-2c0a-4825-b242-da90232a005b")
                },
                new EmployeeRoles
                {
                    EmployeeId = new Guid("24f9aeb4-0f2d-49f9-a7a8-7e61ab56b865"),
                    RoleId = new Guid("19e94a6d-d0c8-4e72-947a-9522c470f073")
                },
                new EmployeeRoles
                {
                    EmployeeId = new Guid("19ba6582-01cf-42bf-b5d8-133a7f6dcc49"),
                    RoleId = new Guid("73483115-6945-4dcf-bc7e-c8834486c94b")
                },
                new EmployeeRoles
                {
                    EmployeeId = new Guid("f3a98a68-21c6-4cfb-95f3-f1be093a12db"),
                    RoleId =new Guid("76bb955d-3a55-4609-b960-2662a0dbff59")
                },
                 new EmployeeRoles
                {
                    EmployeeId = new Guid("f3a98a68-21c6-4cfb-95f3-f1be093a12db"),
                    RoleId = new Guid("19e94a6d-d0c8-4e72-947a-9522c470f073")
                },
                new EmployeeRoles
                {
                    EmployeeId = new Guid("f3a98a68-21c6-4cfb-95f3-f1be093a12db"),
                    RoleId = new Guid("d44e6ed1-2c0a-4825-b242-da90232a005b")
                },
                new EmployeeRoles
                {
                    EmployeeId = new Guid("8e878e79-f71c-4ea9-a3ec-d781d96c69f7"),
                    RoleId = new Guid("73483115-6945-4dcf-bc7e-c8834486c94b")
                },
                new EmployeeRoles
                {
                    EmployeeId = new Guid("7dfd6bcc-19c7-4d4e-b495-d44234596be8"),
                    RoleId = new Guid("76bb955d-3a55-4609-b960-2662a0dbff59")
                },
                new EmployeeRoles
                {
                    EmployeeId = new Guid("7dfd6bcc-19c7-4d4e-b495-d44234596be8"),
                    RoleId = new Guid("19e94a6d-d0c8-4e72-947a-9522c470f073")
                }
            };
        }

        public static IEnumerable<Shift> GetShifts()
        {
            return new List<Shift>()
            {
                new Shift
                {
                    StartTime = new DateTime(2025,01,13,9,0,0),
                    EndTime = new DateTime(2025,01,13,12,0,0),
                    EmployeeId = new Guid("24f9aeb4-0f2d-49f9-a7a8-7e61ab56b865"),
                    RoleId = new Guid("d44e6ed1-2c0a-4825-b242-da90232a005b")
                },
                new Shift
                {
                    StartTime = new DateTime(2025,01,13,13,0,0),
                    EndTime = new DateTime(2025,01,13,17,0,0),
                    EmployeeId = new Guid("24f9aeb4-0f2d-49f9-a7a8-7e61ab56b865"),
                    RoleId = new Guid("19e94a6d-d0c8-4e72-947a-9522c470f073")
                },
                new Shift
                {
                    StartTime = new DateTime(2025,01,13,10,0,0),
                    EndTime = new DateTime(2025,01,13,14,0,0),
                    EmployeeId = new Guid("19ba6582-01cf-42bf-b5d8-133a7f6dcc49"),
                    RoleId = new Guid("73483115-6945-4dcf-bc7e-c8834486c94b")
                },
                new Shift
                {
                    StartTime = new DateTime(2025,01,14,9,0,0),
                    EndTime = new DateTime(2025,01,14,14,0,0),
                    EmployeeId = new Guid("f3a98a68-21c6-4cfb-95f3-f1be093a12db"),
                    RoleId =new Guid("76bb955d-3a55-4609-b960-2662a0dbff59")
                },
                new Shift
                {
                    StartTime = new DateTime(2025,01,14,13,0,0),
                    EndTime = new DateTime(2025,01,14,18,0,0),
                    EmployeeId = new Guid("f3a98a68-21c6-4cfb-95f3-f1be093a12db"),
                    RoleId = new Guid("19e94a6d-d0c8-4e72-947a-9522c470f073")
                },
                new Shift
                {
                    StartTime = new DateTime(2025,01,15,9,0,0),
                    EndTime = new DateTime(2025,01,15,12,0,0),
                    EmployeeId = new Guid("f3a98a68-21c6-4cfb-95f3-f1be093a12db"),
                    RoleId = new Guid("d44e6ed1-2c0a-4825-b242-da90232a005b")
                },
                new Shift
                {
                    StartTime = new DateTime(2025,01,16,9,0,0),
                    EndTime = new DateTime(2025,01,16,11,0,0),
                    EmployeeId = new Guid("8e878e79-f71c-4ea9-a3ec-d781d96c69f7"),
                    RoleId = new Guid("73483115-6945-4dcf-bc7e-c8834486c94b")
                },
                new Shift
                {
                    StartTime = new DateTime(2025,01,17,9,0,0),
                    EndTime = new DateTime(2025,01,17,12,0,0),
                    EmployeeId = new Guid("7dfd6bcc-19c7-4d4e-b495-d44234596be8"),
                    RoleId = new Guid("76bb955d-3a55-4609-b960-2662a0dbff59")
                },
                new Shift
                {
                    StartTime = new DateTime(2025,01,17,13,0,0),
                    EndTime = new DateTime(2025,01,17,16,0,0),
                    EmployeeId = new Guid("7dfd6bcc-19c7-4d4e-b495-d44234596be8"),
                    RoleId = new Guid("19e94a6d-d0c8-4e72-947a-9522c470f073")
                }
            };
        }
    }
}

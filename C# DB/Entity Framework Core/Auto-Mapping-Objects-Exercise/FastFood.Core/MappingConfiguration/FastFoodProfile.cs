namespace FastFood.Core.MappingConfiguration
{
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using Microsoft.EntityFrameworkCore.Internal;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(y => y.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>();

            //Employees
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(y => y.Id))
                .ForMember(x => x.PositionName, y => y.MapFrom(y => y.Name));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(y => y.Position.Name));

            //Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(y => y.Id))
                .ForMember(x => x.CategoryName, y => y.MapFrom(y => y.Name));

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(y => y.Category.Name));

            //Orders
            this.CreateMap<Item, CreateOrderItemViewModel>()
                .ForMember(x => x.ItemName, y => y.MapFrom(y => y.Name))
                .ForMember(x => x.ItemId, y => y.MapFrom(y => y.Id));

            this.CreateMap<Employee, CreateOrderEmployeeViewModel>()
                .ForMember(x => x.EmployeeName, y => y.MapFrom(y => y.Name))
                .ForMember(x => x.EmployeeId, y => y.MapFrom(y => y.Id));

            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(x => x.DateTime, y => y.MapFrom(y => DateTime.UtcNow))
                .ForMember(x => x.Type, y => y.MapFrom(y => OrderType.ToGo));

            this.CreateMap<CreateOrderInputModel, OrderItem>();

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.DateTime, y => y.MapFrom(y => y.DateTime.ToString("D", CultureInfo.InvariantCulture)))
                .ForMember(x => x.Employee, y => y.MapFrom(y => y.Employee.Name))
                .ForMember(x => x.OrderId, y => y.MapFrom(y => y.Id));

        }
    }
}

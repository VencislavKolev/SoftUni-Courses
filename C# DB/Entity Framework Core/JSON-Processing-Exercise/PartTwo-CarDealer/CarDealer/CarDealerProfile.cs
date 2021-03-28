using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.DTO.CustomerDTOs;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<Customer, CustomerTotalSalesDto>()
                .ForMember(x => x.FullName, y => y.MapFrom(x => x.Name))
                .ForMember(x => x.BoughtCars, y => y.MapFrom(x => x.Sales.Count))
                .ForMember(x => x.SpendMoney, y => y.MapFrom(x => x.Sales
                                             .Select(s => s.Car
                                                    .PartCars
                                                    .Select(cp => cp.Part)
                                                    .Sum(cp => cp.Price))
                                             .Sum()));
        }
    }
}

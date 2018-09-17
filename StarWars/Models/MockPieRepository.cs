﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    //If i need to use MockPie repository from different parts of the application 
    //I need to register it using dependancy injection. For that we need to go back to start up.cs class 
    public class MockPieRepository : IPieRepository
    {
        private List<Pie> _pies;

        public MockPieRepository() {
            if (_pies == null) {
                InitializePies();
            }
        }
        private void InitializePies() {
            _pies = new List<Pie>
            {
                new Pie { Id=1,Name="Apple Pie",Price=12.95M,ShortDescription="",LongDescription="",  ImageThumbnailUrl ="", ImageUrl ="", IsPieOfTheWeek=true},
                new Pie { Id=1,Name="Blueberry Pie",Price=11.95M,ShortDescription="",LongDescription="",  ImageThumbnailUrl ="", ImageUrl ="", IsPieOfTheWeek=true},
                new Pie { Id=1,Name="Cheese Cake",Price=15.95M,ShortDescription="",LongDescription="",  ImageThumbnailUrl ="", ImageUrl ="", IsPieOfTheWeek=true},
                new Pie { Id=1,Name="Cherry Pie",Price=10.95M,ShortDescription="",LongDescription="",  ImageThumbnailUrl ="", ImageUrl ="", IsPieOfTheWeek=true}
            };
        }
        IEnumerable<Pie> IPieRepository.GetAllPies()
        {
            return _pies;
        }

        Pie IPieRepository.GetPieByID(int pieId)
        {
            return _pies.FirstOrDefault(p => p.Id == pieId);
        }
    }
}
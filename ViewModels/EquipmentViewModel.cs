using Microsoft.EntityFrameworkCore;
using ShopERP.Models;
using ShopERP.Models.Contexts;
using ShopERP.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShopERP.ViewModels
{
    public class EquipmentViewModel : BaseObjectViewModel<Equipment>
    {
        #region Properties and Fields
        private string _equipmentName;
        public string EquipmentName
        {
            get { return _equipmentName; }
            set
            {
                if (_equipmentName != value)
                {
                    _equipmentName = value;
                    OnPropertyChanged(() => EquipmentName);
                }
            }
        }

        private DateOnly _equipmentAcquireDate;
        public DateOnly EquipmentAcquireDate
        {
            get { return _equipmentAcquireDate; }
            set
            {
                if (_equipmentAcquireDate != value)
                {
                    _equipmentAcquireDate = value;
                    OnPropertyChanged(() => EquipmentAcquireDate);
                }
            }
        }

        private DateOnly? _equipmentServiceDate;
        public DateOnly? EquipmentServiceDate
        {
            get { return _equipmentServiceDate; }
            set
            {
                if (_equipmentServiceDate != value)
                {
                    _equipmentServiceDate = value;
                    OnPropertyChanged(() => EquipmentServiceDate);
                }
            }
        }

        private decimal? _equipmentBoughtPrice;
        public decimal? EquipmentBoughtPrice
        {
            get { return _equipmentBoughtPrice; }
            set
            {
                if (_equipmentBoughtPrice != value)
                {
                    _equipmentBoughtPrice = value;
                    OnPropertyChanged(() => EquipmentBoughtPrice);
                }
            }
        }

        private bool _equipmentIsLeased;
        public bool EquipmentIsLeased
        {
            get { return _equipmentIsLeased; }
            set
            {
                if (_equipmentIsLeased != value)
                {
                    _equipmentIsLeased = value;
                    OnPropertyChanged(() => EquipmentIsLeased);
                }
            }
        }

        private string? _equipmentLeasedFrom;
        public string? EquipmentLeasedFrom
        {
            get { return _equipmentLeasedFrom; }
            set
            {
                if (_equipmentLeasedFrom != value)
                {
                    _equipmentLeasedFrom = value;
                    OnPropertyChanged(() => EquipmentLeasedFrom);
                }
            }
        }
        #endregion

        public EquipmentViewModel() : base("Equipment")
        {

        }

        #region Methods
        public override void Save()
        {
            using (var dbContext = new DatabaseContext())
            {
                var equipment = new Equipment
                {
                    EquipmentName = EquipmentName,
                    EquipmentAcquireDate = EquipmentAcquireDate,
                    EquipmentServiceDate = EquipmentServiceDate,
                    EquipmentBoughtPrice = EquipmentBoughtPrice,
                    EquipmentIsLeased = EquipmentIsLeased,
                    EquipmentLeasedFrom = EquipmentLeasedFrom,
                    DateCreated = DateTime.Now
                };
                dbContext.Equipment.Add(equipment);
                dbContext.SaveChanges();
            }
            Refresh();
        }

        public override void Delete()
        {
            if (SelectedModel != null)
            {
                using (var dbContext = new DatabaseContext())
                {
                    var equipment = dbContext.Equipment.Find(SelectedModel.EquipmentId);
                    equipment.DateDeleted = DateTime.Now;
                    dbContext.SaveChanges();
                }
                Refresh();
            }
        }

        public override void Edit()
        {
            if (SelectedModel != null)
            {
                using (var dbContext = new DatabaseContext())
                {
                    var equipment = dbContext.Equipment.Find(SelectedModel.EquipmentId);
                    equipment.EquipmentName = SelectedModel.EquipmentName;
                    equipment.EquipmentAcquireDate = SelectedModel.EquipmentAcquireDate;
                    equipment.EquipmentServiceDate = SelectedModel.EquipmentServiceDate;
                    equipment.EquipmentBoughtPrice = SelectedModel.EquipmentBoughtPrice;
                    equipment.EquipmentIsLeased = SelectedModel.EquipmentIsLeased;
                    equipment.EquipmentLeasedFrom = SelectedModel.EquipmentLeasedFrom;
                    equipment.DateEdited = DateTime.Now;
                    dbContext.SaveChanges();
                    SelectedModel = null;
                }
                Refresh();
            }
        }

        public override IEnumerable<Equipment> GetModels()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Equipment.Where(e => e.DateDeleted == null).ToList();
            }
        }
        #endregion
    }
}

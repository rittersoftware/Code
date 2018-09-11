using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Core.Domain.Annotations;

namespace Core.Domain.Entities.Common
{
    [Table("Address")]
    public class Address : INotifyPropertyChanged, INotifyPropertyChanging
    {
        [Key]
        public virtual Guid AddressId { get; set; } = Guid.NewGuid();
        public virtual string Street { get; set; }
        public virtual string Unit { get; set; }
        public virtual string City { get; set; }
        public virtual States State { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual bool IsPrimaryAddress { get; set; }
        public virtual AddressType AddressType { get; set; }
        public virtual decimal Latitude { get; set; }
        public virtual decimal Longitude { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangingEventHandler PropertyChanging;
    }
}

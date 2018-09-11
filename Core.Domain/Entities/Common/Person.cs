using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Core.Domain.Annotations;
using Core.Domain.Entities.Security;

namespace Core.Domain.Entities.Common
{
    [Table("Person")]
    public class Person : INotifyPropertyChanged
    {
        [Key] public virtual Guid PersonId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDateTime => new DateTime();
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Core.Domain.Annotations;

namespace Core.Domain.Entities.Specific
{
    [Table("Notifications")]
    public class Notifications : INotifyPropertyChanged
    {
        [Key] public virtual Guid NotificationId { get; set; } = Guid.NewGuid();
        public virtual string Title { get; set; }
        public virtual string Details { get; set; }
        public virtual int NumberOfAttempts { get; set; }
        public virtual DateTime? NotificationEntered { get; set; }
        public virtual DateTime? NotificationStart { get; set; }
        public virtual DateTime? NotificationEnd { get; set; }
        public virtual string Parameters { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Core.Domain.Annotations;

namespace Core.Domain.Entities.Common
{
    [Table("History")]
    public class History : INotifyPropertyChanged
    {
       [Key] public virtual Guid HistoryId { get; set; } = Guid.NewGuid();
        public virtual string Details { get; set; }
        public virtual DateTime CreatedDateTime { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
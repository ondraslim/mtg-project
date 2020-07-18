using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Common.Entities
{
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Unique entity identification
        /// </summary>
        [Key]
        TKey Id { get; set; }
    }
}
using System;

namespace BusinessLayer.DTOs.Common
{
    public class BaseDto
    {
        /// <summary>
        /// Id of transfered object
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Date of creation of transfered object
        /// </summary>
        public DateTime Created { get; set; } = DateTime.Now;
    }
}

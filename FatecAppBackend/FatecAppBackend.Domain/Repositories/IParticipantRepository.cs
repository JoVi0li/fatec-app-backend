using FatecAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Domain.Repositories
{
    public interface IParticipantRepository
    {
        /// <summary>
        /// Create a new Participant
        /// </summary>
        /// <param name="participant">Participant props</param>
        void Create(Participant participant);

        /// <summary>
        /// Remove a Participant
        /// </summary>
        /// <param name="id">Participant Id</param>
        void Remove(Guid id);

        /// <summary>
        /// Get Participant by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Participant? GetById(Guid id);

        /// <summary>
        /// Get Participants by EventId
        /// </summary>
        /// <param name="id">EventId</param>
        /// <returns>A list of Participants</returns>
        ICollection<Participant>? GetByEventId(Guid id);

        /// <summary>
        /// Get Participants by UserCollegeId
        /// </summary>
        /// <param name="id">UserCollegeId</param>
        /// <returns>A list of Participants</returns>
        ICollection<Participant>? GetByUserCollegeId(Guid id);

        /// <summary>
        /// Update a Participant
        /// </summary>
        /// <param name="participant">Participant props</param>
        void Update(Participant participant);
    }
}

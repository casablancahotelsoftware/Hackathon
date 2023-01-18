using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VitualReception.Domain.Model
{
    /// <summary>
    /// Represents a collection of <see cref="Chat"/> instances.
    /// </summary>
    public interface IChatRepository
    {
        /// <summary>
        /// Finds a <see cref="Chat"/> instance by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of a <see cref="Chat"/> instance.</param>
        /// <returns>A <see cref="Chat"/> instance or <c>null</c> if not found.</returns>
        Task<Chat> FindAsync(Guid id);

        /// <summary>
        /// Retruns a <see cref="Chat"/> instances in the collection.
        /// </summary>
        /// <returns>A collection of <see cref="Chat"/> instances.</returns>
        Task<IEnumerable<Chat>> FindAllAsync();

        /// <summary>
        /// Returns all <see cref="Chat"/> instances that are associated with a given <see cref="Member"/> 
        /// identifierd by the provided <paramref name="memberId"/>.
        /// </summary>
        /// <param name="memberId">The unique identifier of a <see cref="Member"/> instance.</param>
        /// <returns>A collection of <see cref="Chat"/> instances associated with a <see cref="Member"/>.</returns>
        Task<IEnumerable<Chat>> FindAllByMemberAsync(Guid memberId);

        /// <summary>
        /// Adds a new <see cref="Chat"/> to the collection.
        /// </summary>
        /// <param name="chat">The new <see cref="Chat"/> instance.</param>
        /// <returns></returns>
        Task AddAsync(Chat chat);

        /// <summary>
        /// Removes a <see cref="Chat"/> instance from the collection.
        /// </summary>
        /// <param name="chat">The <see cref="Chat"/> instance to remove.</param>
        /// <returns></returns>
        Task RemoveAsync(Chat chat);
    }
}

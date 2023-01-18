using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitualReception.Domain.Model;

namespace VirtualReception.Server.Infrastructure
{
    /// <summary>
    /// In-Memory implementation of the <see cref="IChatRepository"/> interface also providing some fake data.
    /// </summary>
    public class FakeChatRepository : IChatRepository
    {
        #region fake-data

        private readonly HashSet<Chat> _chats = new();

        public FakeChatRepository()
        {
            var member_1 = new Member(Guid.Parse("e77d4178-5e50-419e-8c5f-7d148b7bf5e8"), "Max Mustergast");
            var member_2 = new Member(Guid.Parse("e77d4178-5e50-419e-8c5f-7d148b7bf5e7"), "Maria Muterrezeptionistin");
            var chat = new Chat(Guid.Parse("1a5d8570-e1c4-43da-9463-f703e5098f38"), "Maria Mustergast")
            { Members = new HashSet<Member> { member_1, member_2 } };

            chat.CreateMessage(member_1.Id, "Sehr geehrte Damen und Herren, ich möchte mich zu meiner Buchung informieren");
            chat.CreateMessage(member_2.Id, "Können Sie mir bitte Ihre Buchungnummer zukommen lassen");

            _chats.Add(chat);
        }

        #endregion

        public Task AddAsync(Chat chat) => Task.FromResult(_chats.Add(chat));

        public Task<Chat> FindAsync(Guid id) => Task.FromResult(_chats.SingleOrDefault(chat => chat.Id == id));

        public Task<IEnumerable<Chat>> FindAllAsync() => Task.FromResult<IEnumerable<Chat>>(_chats);

        public Task RemoveAsync(Chat chat) => Task.FromResult(_chats.Remove(chat));

        public Task UpdateAsync(Chat chat) => Task.FromResult(() =>
        {
            var chatToUpdate = _chats.SingleOrDefault(chat => chat.Id == chat.Id);
            chatToUpdate = chat;
        });

        public Task<IEnumerable<Chat>> FindAllByMemberAsync(Guid memberId) => Task.FromResult(
            _chats.Where(chat => chat.Members.Select(x => x.Id).Contains(memberId)));
    }
}

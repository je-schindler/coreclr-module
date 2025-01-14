using System;
using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.ColShape.Tests
{
    public class MockPlayerPool : IEntityPool<IPlayer>
    {
        private readonly List<IPlayer> players;
        
        public MockPlayerPool(List<IPlayer> players)
        {
            this.players = players;
        }
        
        public void Create(IntPtr entityPointer, ushort id)
        {
            throw new NotImplementedException();
        }

        public void Create(IntPtr entityPointer, ushort id, out IPlayer entity)
        {
            throw new NotImplementedException();
        }

        public void Create(IntPtr entityPointer, out IPlayer entity)
        {
            throw new NotImplementedException();
        }

        public void Add(IPlayer entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IPlayer entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IntPtr entityPointer)
        {
            throw new NotImplementedException();
        }

        public bool Get(IntPtr entityPointer, out IPlayer entity)
        {
            throw new NotImplementedException();
        }

        public bool GetOrCreate(IntPtr entityPointer, ushort entityId, out IPlayer entity)
        {
            throw new NotImplementedException();
        }

        public bool GetOrCreate(IntPtr entityPointer, out IPlayer entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<IPlayer> GetAllEntities()
        {
            return players;
        }

        public void OnAdd(IPlayer entity)
        {
            throw new NotImplementedException();
        }

        public void OnRemove(IPlayer entity)
        {
            throw new NotImplementedException();
        }
    }
}
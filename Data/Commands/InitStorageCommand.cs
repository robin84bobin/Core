using System.Collections.Generic;
using Core.Core.Commands;
using Core.Core.Data.Proxy;
using Core.Core.Data.Repository;
using UnityEngine;

namespace Core.Core.Data.Commands
{

    public class InitStorageCommand<T> : Command where T : DataItem, new()
    {
        private IDataProxyService _dataProxyService;
        private DataStorage<T> _storage;

        public InitStorageCommand(DataStorage<T> storage, IDataProxyService dataProxyService)
        {
            _dataProxyService = dataProxyService;
            _storage = storage;
        }

        public override void Execute()
        {
            Debug.Log(this + " --> " + _storage.CollectionName);
            _dataProxyService.Get<T>(_storage.CollectionName, OnGetData);
        }

        private void OnGetData(Dictionary<string, T> items)
        {
            _storage.SetData(items);
            Complete();
        }

        protected override void Release()
        {
            base.Release();
            _storage = null;
        }
    }
}
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Core.Core.Services.ResourceService
{
    public class AddressablesResourcesService : IResourcesService
    {
        public async void LoadScene(string sceneName, LoadSceneMode mode)
        {
            var handle = Addressables.LoadSceneAsync(sceneName, mode);
            await handle.Task;
        }

        public async Task<string> LoadTextFile(string path)
        {
            var handle = Addressables.LoadAssetAsync<TextAsset>(path);
            var t =  await handle.Task;
            return t.text;
        }

        public async Task<T> LoadComponentFromPrefab<T>(string path) where T:UnityEngine.Object
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(path);
            var gameObject =  await handle.Task;
            var component = gameObject.GetComponent<T>();
            return component;
        }

        public async Task<GameObject> LoadPrefab(string path)
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(path);
            var gameObject =  await handle.Task;
            return gameObject;
        }
    }
}
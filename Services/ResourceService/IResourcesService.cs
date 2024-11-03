using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Core.Services.ResourceService
{
    public interface IResourcesService
    {
        void LoadScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single);
        Task<string> LoadTextFile(string path);
        Task<T> LoadComponentFromPrefab<T>(string path) where T:UnityEngine.Object;
        Task<GameObject> LoadPrefab(string path);
    }
}
using Core.Core.Commands;
using Core.Core.Data.Repository;

namespace Core.Core.Data.Commands
{
    public class InitDataRepositoryCommand : Command
    {
        private BaseDataRepository _baseDataRepository;

        public InitDataRepositoryCommand(BaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;
        }
        
        public override void Execute()
        {
            _baseDataRepository.OnInitComplete += OnInitComplete;
            _baseDataRepository.OnInitProgress += SetProgress;
            _baseDataRepository.Init();
        }

        private void OnInitComplete()
        {
            _baseDataRepository.OnInitProgress -= SetProgress;
            _baseDataRepository.OnInitComplete -= OnInitComplete;
            Complete();
        }
    }
}
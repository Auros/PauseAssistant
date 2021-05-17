using System;
using System.Collections.Generic;
using System.Text;
using Zenject;

namespace PauseAssistant.Managers
{
    internal class PauseCogManager : IInitializable
    {
        private readonly PauseMenuManager _pauseMenuManager;

        public PauseCogManager(PauseMenuManager pauseMenuManager)
        {
            _pauseMenuManager = pauseMenuManager;
        }

        public void Initialize()
        {
            
        }
    }
}

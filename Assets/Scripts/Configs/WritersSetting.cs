using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "WritersSetting", menuName = "Configs/Create Writers Setting", order = 51)]
    public class WritersSetting : ScriptableObject
    {
        [SerializeField] private List<AuthorDataWrapper> writers = new List<AuthorDataWrapper>();
        private int chosenWriter;
        public List<AuthorDataWrapper> Writers => writers;
        public int ChosenWriter
        {
            get => chosenWriter;
            set
            {
                writers[chosenWriter].IsUser = false;
                chosenWriter = value;
                writers[chosenWriter].IsUser = true;
            }
        }

        public AuthorDataWrapper GetCurrentAuthor()
        {
            Debug.Assert(writers!=null && writers.Count > ChosenWriter,"Провертье настройки Авторов");
            return writers[ChosenWriter];
        }

        int index;
        public AuthorDataWrapper GetRandomAuthor()
        {
            Debug.Assert(writers != null && writers.Count > 0, "Провертье настройки Авторов");
            index = UnityEngine.Random.Range(0, writers.Count);
            return writers[index];
        }

    }

    [Serializable]
    public class AuthorDataWrapper
    {
        public AuthorData Data;
        [HideInInspector]public bool IsUser;
    }
}

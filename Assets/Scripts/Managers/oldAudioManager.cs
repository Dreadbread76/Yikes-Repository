using UnityEngine;
using UnityEngine.Audio;

namespace EggRunner.Lara
{
    public class oldAudioManager : MonoBehaviour
    {
        public AudioMixer audioMaster;
        private AudioSource audioSource;
        public AudioClip bgMusic;
        public AudioClip volcanoBoom;

        // Start is called before the first frame update
        void Start()
        {
            LoadPlayerPrefs();
        }

        /// <summary>
        /// Connected exposed music parameters to script for control here.
        /// </summary>
        /// <param name="musicVol">Music/background control param</param>
        public void SetVolume(float musicVol)
        {
            audioMaster.SetFloat("musicVol", musicVol);
        }

        /// <param name="soundFXVol">Sound effects control param.</param>
        public void SoundFX(float soundFXVol)
        {
            audioMaster.SetFloat("soundFXVol", soundFXVol);
        }

        /// <summary>
        /// Save Music and sound effects.
        /// </summary>
        public void SavePlayerPrefs()
        {
            float musicVol;
            if(audioMaster.GetFloat("musicVol", out musicVol))
            {
                PlayerPrefs.SetFloat("musicVol", musicVol);
            }

            float soundFXVol;
            if(audioMaster.GetFloat("soundFXVol", out soundFXVol))
            {
                PlayerPrefs.SetFloat("soundFXVol", soundFXVol);
            }

            PlayerPrefs.Save();
        }

        /// <summary>
        /// Load Audio prefs
        /// </summary>
        public void LoadPlayerPrefs()
        {
            if (PlayerPrefs.HasKey("musicVol"))
            {
                float musicVol = PlayerPrefs.GetFloat("musicVol");
                //Connect slider value to float
                //musicSlider.value = musicVol;
                audioMaster.SetFloat("musicVol", musicVol);
            }
            if (PlayerPrefs.HasKey("soundFXVol"))
            {
                float soundFXVol = PlayerPrefs.GetFloat("soundFXVol");
                //Connect slider value to float
                //SFXSlider.value = SFXVol;
                audioMaster.SetFloat("SFXVol", soundFXVol);
            }
        }

        public void PlayBackgroundMusic()
        {
            audioSource.clip = bgMusic;
            audioSource.Play();
        }

        public void PlayVolcanoBoom()
        {
            audioSource.clip = volcanoBoom;
            audioSource.PlayOneShot(volcanoBoom);
        }
    }
}

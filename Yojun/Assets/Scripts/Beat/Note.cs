using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Note : MonoBehaviour
{

    private bool canBePlayed;

    public int playerWanted;
    private PlayerStrummingBar playerWantedScript;

    public AudioMixer mixer;

    public AudioClip clip;
    public AudioMixerGroup channel;

    public enum ChannelType {kick, clap, snare, hihat, ride, crash, tomA, tomB, tomC, bell}
    public ChannelType selectChannel;

    private bool HasBeenPlayed;
    private float timeToReactivate;

    private SpriteRenderer sR;

    private Color[] colors = new Color[12];
    private Color myColor;

    void Start()
    {

        if (mixer.FindMatchingGroups(selectChannel.ToString()) != null)
        {
            AudioMixerGroup[] audioMixGroup = mixer.FindMatchingGroups(selectChannel.ToString());
            channel = audioMixGroup[0];
        }
        else
        {
            Debug.Log("mixerGroup Does not exist");
        }
        sR = GetComponent<SpriteRenderer>();

        colors[0] = new Color(1, 0, 0);
        colors[1] = new Color(1, 0.5f, 0);
        colors[2] = new Color(1, 1, 0);
        colors[3] = new Color(0.5f, 1, 0);
        colors[4] = new Color(0, 1, 0);
        colors[5] = new Color(0, 1, 0.5f);
        colors[6] = new Color(0, 1, 1);
        colors[7] = new Color(0, 0.5f, 1);
        colors[8] = new Color(0, 0, 1);
        colors[9] = new Color(0.5f, 0, 1);
        colors[10] = new Color(1, 0, 1);
        colors[11] = new Color(1, 0, 0.5f);

        myColor = colors[playerWanted - 1];

        sR.color = myColor;
    }


    void Update()
    {
        if (canBePlayed)
        {
            if (playerWantedScript.IsPressed && !HasBeenPlayed)
            {
                playerWantedScript.PlayNote(clip, channel);
                HasBeenPlayed = true;
                sR.color = Color.gray;
            }            
        }

        if (HasBeenPlayed)
        {
            timeToReactivate += Time.deltaTime;

        }
        if (timeToReactivate >= 2f)
        {
            HasBeenPlayed = false;
            sR.color = myColor;
            timeToReactivate = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerStrummingBar>().playerNumber == playerWanted)
            {
                playerWantedScript = collision.gameObject.GetComponent<PlayerStrummingBar>();
                canBePlayed = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canBePlayed = false;
    }
}

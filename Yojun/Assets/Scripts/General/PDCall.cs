
using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Net.Sockets;


public class PDCall : MonoBehaviour
{

    private UdpClient client;
    private ASCIIEncoding asen;
    private int number;

    private byte[] ba;



    void Start()
    {
        client = new UdpClient();
       // client.Connect("192.168.0.21", 8063);
        client.Connect("127.0.0.1", 8063);

        asen = new ASCIIEncoding();
       // InvokeRepeating("SoundUpdate", 1, 0.3f);

      //  inputNumber2 = 20;
    }


    void Update()
    {



        if (Input.GetKeyDown(KeyCode.A))
        {
            EquipeAUpdate(0);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            EquipeAUpdate(1);

        }

      
        if (Input.GetKeyDown(KeyCode.Z))
        {
            EquipeBUpdate(0);
      
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            EquipeBUpdate(1);
      
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            PointUpdate(0);

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            PointUpdate(1);

        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            WinnerUpdate(0);

        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            WinnerUpdate(1);

        }


    }

    //Envoyer String de 8 caractères (l'espace n'a pas l'air de compter) !

   public void EquipeAUpdate(int i)
    {
        string msg = "/EquipeA " + i;
       byte[] ba = asen.GetBytes(msg);
      client.Send(ba, ba.Length);

    }

    public void EquipeBUpdate(int i)
    {
        string msg = "/EquipeB " + i;
        byte[] ba = asen.GetBytes(msg);
        client.Send(ba, ba.Length);

    }

    public void PointUpdate(int i)
    {
        string msg = "/Point__ " + i;
        byte[] ba = asen.GetBytes(msg);
        client.Send(ba, ba.Length);

    }

    public void WinnerUpdate(int i)
    {
        string msg = "/Winner_ " + i;
        byte[] ba = asen.GetBytes(msg);
        client.Send(ba, ba.Length);

    }


    //  void Send(string str)
    //  {
    //       byt = asen.GetBytes(str);
    //      client.Send(byt, byt.Length);
    //  }

}

using UnityEngine;
public class TopKontrol : MonoBehaviour
{
    private Rigidbody rb;
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Text zaman, can, durum;
    float zamanSayaci = 12;
    int canSayaci = 3;
    private bool oyunTamamlanamadi = true;
    private bool oyunTamamlandi = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        if (oyunTamamlanamadi&&!oyunTamamlandi)
        {
            zamanSayaci -= Time.deltaTime;
            zaman.text =(int)zamanSayaci+"";
        }
        else if(!oyunTamamlandi)
        {
            durum.text = "Oyunu Kaybettin :(";
            btn.gameObject.SetActive(true);
        }
        else
        {
            durum.text = "Oyunu Kazandınız. Tebrikler";
            btn.gameObject.SetActive(true);
        }
        if (zamanSayaci<=0||canSayaci==0)
        {
            oyunTamamlanamadi = false;
        }
    }

    private void FixedUpdate()
    {
        if (oyunTamamlanamadi&&!oyunTamamlandi)
        {
            float dikey = Input.GetAxis("Horizontal");
            float yatay = Input.GetAxis("Vertical");
            Vector3 kontrol = new Vector3(dikey, 0, yatay);
            rb.AddForce(kontrol*6f);
        }
        else
        {
            rb.velocity=Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }


    }

    private void OnCollisionEnter(Collision cld)
    {
        string objİsmi = cld.gameObject.name;  
        if (objİsmi == "duvar")
        {
            canSayaci -= 1;
            can.text = canSayaci.ToString();
        }
        if (objİsmi=="Bitis")
        {
            oyunTamamlandi = true;
        }
    }
}

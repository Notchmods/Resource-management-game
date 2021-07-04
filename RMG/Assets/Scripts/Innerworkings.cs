using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Innerworkings : MonoBehaviour
{

    public float currency;//money
    public float days; //The day
    public float factories; //factories that proccesses the resources
    public float moneyperday;
    //Checkwhetherthegameisnew
    public bool newgame;
    //Sectors
    public bool Coal;
    public bool Timber;
    public bool Agricultural;
    public float consumergoods;
    public float coalamount;
    public float Timberamount;
    public float Agriculturalamount;
    public float Oilamount;
    public float Silveramount;
    public float automobileamount;
    public float coalworth;
    public float timberworth;
    public float agriworth;
    public float oilworth;
    public float silvworth;
    public float Consumergoodworth;
    public float automobilesworth;
    public float factoriesproduction;
    public Text day;
    public Text Currencydisplay;
    public Text Factorydisplay;
    public Text Coalamountdis;
    public Text Timberamountdis;
    public Text Agriamountdis;
    public Text Oilamountdis;
    public Text Silvamountdis;
    public Text Consoomdis;
    public Text autodis;
    public GameObject[] Notenough;
    void Start()
    {
        //If it's not a new game then get the previous save and load all the variables
        if(newgame == false)
        {
            //Store the loaded variables
            float Currencysave = PlayerPrefs.GetInt("Currency");
            float Daysave = PlayerPrefs.GetInt("Timedays");
            float factory = PlayerPrefs.GetInt("Factories");
            float coalsaved = PlayerPrefs.GetInt("Coalown");
            float Timbersaved = PlayerPrefs.GetInt("Woodown");
            float agrisavedd = PlayerPrefs.GetInt("Agriculturalown");
            float Oilloading = PlayerPrefs.GetInt("Oilsaved");
            float Silverloading = PlayerPrefs.GetInt("Silversave");
            float Consoomergoodsloading = PlayerPrefs.GetInt("Consumergoodssaved");
            float Autosaveds = PlayerPrefs.GetInt("Automobilessaved");
            //Loading variables
            currency = Currencysave;
            Currencydisplay.text = currency.ToString();
            days = Daysave;
            day.text = days.ToString();
            factories = factory;
            Factorydisplay.text = factories.ToString();
            coalamount = coalsaved;
            Timberamount = Timbersaved;
            Agriculturalamount = agrisavedd;
            Oilamount = Oilloading;
            Silveramount = Silverloading;
            consumergoods = Consoomergoodsloading;
            automobileamount = Autosaveds;
            Coalamountdis.text = coalamount.ToString();
            Timberamountdis.text = Timberamount.ToString();
            Agriamountdis.text = Agriculturalamount.ToString();
            Oilamountdis.text = Oilamount.ToString();
            Silvamountdis.text = Silveramount.ToString();
            Consoomdis.text = consumergoods.ToString();
            autodis.text = automobileamount.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {        
        //Convert float to text
        Currencydisplay.text = "Money: "+(int)currency;
        day.text = "Day: " + (int)days;
        Factorydisplay.text = "Factories:"+(int)factories;
        Coalamountdis.text = coalamount.ToString();
        Timberamountdis.text = Timberamount.ToString();
        Agriamountdis.text = Agriculturalamount.ToString();
        Oilamountdis.text = Oilamount.ToString();
        Silvamountdis.text = Silveramount.ToString();
        Consoomdis.text = consumergoods.ToString();
        autodis.text = automobileamount.ToString();
        coalworth = coalamount * 25;
        timberworth = Timberamount * 25;
        agriworth = Agriculturalamount * 25;
        oilworth = Oilamount * 100;
        silvworth = Silveramount * 300f;
        factoriesproduction = factories * 200;
        Consumergoodworth = consumergoods * 500f;
        automobilesworth = automobileamount * 1000f;
        //If selected one of those industries then they'll make x amount of currency per day
        if(newgame == true)
        {
            if (Coal == true || Timber == true || Agricultural == true)
            {
                currency += (coalworth + timberworth + agriworth+factoriesproduction+Consumergoodworth+oilworth+silvworth+automobilesworth) * Time.deltaTime;
                //Make the day goes one second per day
                days += 1f * Time.deltaTime;
            }
        }else
        {
            currency += (coalworth + timberworth + agriworth + factoriesproduction + Consumergoodworth + oilworth + silvworth) * Time.deltaTime;
            //Make the day goes one second per day
            days += 1f * Time.deltaTime;
        }

        //Save variables
        PlayerPrefs.SetInt("Currency",(int)currency);
        PlayerPrefs.SetInt("Factories", (int)factories);
        PlayerPrefs.SetInt("Timedays", (int)days);
        PlayerPrefs.SetInt("Woodown", (int)Timberamount);
        PlayerPrefs.SetInt("Coalown", (int)coalamount);
        PlayerPrefs.SetInt("Agriculturalown", (int)Agriculturalamount);
        PlayerPrefs.SetInt("Oilsaved", (int)Oilamount);
        PlayerPrefs.SetInt("Silversave", (int)Silveramount);
        PlayerPrefs.SetInt("Consumergoodssaved", (int)consumergoods);
        PlayerPrefs.SetInt("Automobilessaved", (int)automobileamount);
        PlayerPrefs.Save();
    }
    //Initial selection of industry
    public void Initselectedcoal()
    {
        coalamount = 1;
        Coal = true;
    }
    public void Initselectedtimber()
    {
        Timberamount = 1;
        Timber = true;
    }   
    public void Initselectedagricultural()
    {
        Agriculturalamount = 1;
        Agricultural = true;
    }

    //If you've clicked on the industry button, it'll add the industry thus increasing your wealth
    //If you don't have enough money then it'll display a warning
    public void Selectedcoal()
    {
        if(currency >= 1500)
        {
            coalamount += 1f;
            currency -= 1500f;
        }else
        {
            StartCoroutine(Notenoughs());
        }
    }
    public void SelectedTimber()
    {
        if (currency >= 1500)
        {
            Timberamount += 1f;
            currency -= 1500f;
        }
        else
        {
            StartCoroutine(Notenoughs());
        }
    }
    public void SelectedAgriculture()
    {
        if (currency >= 1500)
        {
           Agriculturalamount += 1f;
            currency -= 1500f;
        }
        else
        {
            StartCoroutine(Notenoughs());
        }
    }
    public void SelectedPetro()
    {
        if(currency >= 5000)
        {
            Oilamount += 1f;
            currency -= 5000f;
        }
        else
        {
            StartCoroutine(Notenoughs());
        }
    }
    public void SelectedSilver()
    {
        if (currency >= 10000)
        {
            Silveramount += 1f;
            currency -= 10000f;
        }
        else
        {
            StartCoroutine(Notenoughs());
        }
    }

    public void SelectedConsumergoods()
    {
        if (currency >= 20000)
        {
            if (factories >= 1&&Silveramount>=1)
            {
                consumergoods += 1f;
                currency -= 20000f;
                factories -= 1f;
                Silveramount -= 1f;
            }
            else
            {
                StartCoroutine(Notenoughsconsumer());
            }
        }else
        {
            StartCoroutine(Notenoughsconsumer());
        }
    }

    public void Automobilesselected()
    {
        if (currency >= 50000)
        {
            if (factories >= 1 && Silveramount >= 1&&Oilamount>=1)
            {
                automobileamount += 1f;
                currency -= 50000f;
                factories -= 1f;
                Silveramount -= 1f;
                Oilamount -= 1f;
            }else
            {
                StartCoroutine(Notenoughscar());
            }
        }
        else
        {
            StartCoroutine(Notenoughscar());
        }
    }

    public void buildfactory()
    {
        if(currency >= 30000)
        {
            factories += 1f;
            currency -= 30000f;
        }else
        {
            StartCoroutine(Notenoughs());
        }
    }

    //Display the warning for a second
    IEnumerator Notenoughs()
    {
        Notenough[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Notenough[0].gameObject.SetActive(false);
    }
    IEnumerator Notenoughsconsumer()
    {
        Notenough[1].gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Notenough[1].gameObject.SetActive(false);
    }

    IEnumerator Notenoughscar()
    {
        Notenough[2].gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Notenough[2].gameObject.SetActive(false);
    }
}

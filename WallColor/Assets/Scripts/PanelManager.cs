using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [Header("Tablet Panels")]
    [SerializeField] Panel[] firstRowPanels;
    [SerializeField] Panel[] secondRowPanels;
    [SerializeField] Panel[] thirdRowPanels;
    [SerializeField] Panel[] fourthRowPanels;
    [SerializeField] Panel[] fifthRowPanels;
    [SerializeField] Panel[] sixthRowPanels;
    [SerializeField] Panel[] seventhRowPanels;
    [SerializeField] Panel[] eightRowPanels;
    [SerializeField] Panel[] ninthRowPanels;
    [SerializeField] Panel[] tenthRowPanels;

    [Header("Madrix Panels")]
    [SerializeField] MadrixPanel[] firstRowMadrixPanels;
    [SerializeField] MadrixPanel[] secondRowMadrixPanels;
    [SerializeField] MadrixPanel[] thirdRowMadrixPanels;
    [SerializeField] MadrixPanel[] fourthRowMadrixPanels;
    [SerializeField] MadrixPanel[] fifthRowMadrixPanels;
    [SerializeField] MadrixPanel[] sixthRowMadrixPanels;
    [SerializeField] MadrixPanel[] seventhRowMadrixPanels;
    [SerializeField] MadrixPanel[] eightRowMadrixPanels;
    [SerializeField] MadrixPanel[] ninthRowMadrixPanels;
    [SerializeField] MadrixPanel[] tenthRowMadrixPanels;

    private void Start()
    {
        for(int i = 0; i < firstRowPanels.Length; i++)
        {
            firstRowPanels[i].selectPanel.AddListener(firstRowMadrixPanels[i].SetEmissionColor);
            secondRowPanels[i].selectPanel.AddListener(secondRowMadrixPanels[i].SetEmissionColor);
            thirdRowPanels[i].selectPanel.AddListener(thirdRowMadrixPanels[i].SetEmissionColor);
            fourthRowPanels[i].selectPanel.AddListener(fourthRowMadrixPanels[i].SetEmissionColor);
            fifthRowPanels[i].selectPanel.AddListener(fifthRowMadrixPanels[i].SetEmissionColor);
            sixthRowPanels[i].selectPanel.AddListener(sixthRowMadrixPanels[i].SetEmissionColor);
            seventhRowPanels[i].selectPanel.AddListener(seventhRowMadrixPanels[i].SetEmissionColor);
            eightRowPanels[i].selectPanel.AddListener(eightRowMadrixPanels[i].SetEmissionColor);
            ninthRowPanels[i].selectPanel.AddListener(ninthRowMadrixPanels[i].SetEmissionColor);
            tenthRowPanels[i].selectPanel.AddListener(tenthRowMadrixPanels[i].SetEmissionColor);
        }
    }
}

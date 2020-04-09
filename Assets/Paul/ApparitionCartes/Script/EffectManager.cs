using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [Header("AugmentationDureeDeVieTorche")]
    [Header("Les valeurs en slider sont des multiplicateurs")]

    [Range(0,1)]
    public float _multiplicateurDureeVieTorche; // Done
    [Header("AugmentationDistanceRayonDeLumiere")]
    [Range(1,5)]
    public float _multiplicateurDistanceRayonLumiere; //Done
    [Header("CapacityBatteryMax")]
    [Range(1,2)]
    public float _capacityMax; //Done
    [Header("TempsRechargementPiege")]
    [Range(1,2)]
    public float _multiplicateurRechargementPiege; //To Do
    [Header("RalentissementMob")]
    [Range(0,1)]
    public float _multiplicateurVitesseMob; // To Do
    [Header("Projecteur")]
    [HideInInspector] public bool _isProjecteurCollected; // To Do
    [Header("AugmentationDureePieges")]
    [Range(1,2)]
    public float _multiplicateurDureeViePiege; //To Do
    [Header("AugmentationZonePieges")]
    [Range(1, 2)]
    public float _multiplicateurZonePiege;//To Do
    [Header("RechargePlusRapide")]
    [Range(1,2)]
    public float _multiplicateurRechargeBatterie; // Done

    //Liste de couleurs

    //[Header("ChangementCouleurDeLaLampe")] // To DO

    //[Header("DiminutionFolie")]
    //public float _multiplicateurDureeVieTorche; // To To
}

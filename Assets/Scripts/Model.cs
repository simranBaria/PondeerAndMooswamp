using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor.SpeedTree.Importer;
using UnityEngine;
using UnityEngine.UI;

public class Model : MonoBehaviour
{
    public Pokemon active;
    public bool shiny;
    public PokemonModel model;
    public List<PokemonModel> pokemonModels;
    public List<Button> buttons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        model = pokemonModels[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendOut()
    {
        model.animator.Play("SendOut");
    }

    public void Idle()
    {
        model.animator.Play("Idle");
    }

    public void PhysicalAttack()
    {
        model.animator.Play("PhysicalAttack");
    }

    public void SpecialAttack()
    {
        model.animator.Play("SpecialAttack");
    }

    public void Hurt()
    {
        model.animator.Play("Hurt");
    }

    public void Faint()
    {
        model.animator.Play("Faint");
    }

    public void SwitchPokemon()
    {
        model.model.SetActive(false);
        if (active == Pokemon.Pondeer)
        {
            active = Pokemon.Mooswamp;
            model = pokemonModels[1];
            model.model.SetActive(true);
        }
        else
        {
            active = Pokemon.Pondeer;
            model = pokemonModels[0];
            model.model.SetActive(true);
        }
    }

    public void SwitchShiny()
    {
        if (shiny)
        {
            foreach (SkinnedMeshRenderer mesh in model.meshes)
            {
                if (mesh.materials.Length > 1)
                {
                    Material[] materials = mesh.materials;
                    if(active == Pokemon.Pondeer)
                    {
                        materials[0] = model.materials[0];
                        materials[1] = model.materials[1];
                    }
                    else
                    {
                        materials[1] = model.materials[0];
                        materials[0] = model.materials[1];
                    }
                        mesh.materials = materials;
                }
                else mesh.material = model.materials[0];
            }

            shiny = false;
        }
        else
        {
            foreach (SkinnedMeshRenderer mesh in model.meshes)
            {
                if (mesh.materials.Length > 1)
                {
                    Material[] materials = mesh.materials;
                    if (active == Pokemon.Pondeer)
                    {
                        materials[0] = model.materials[2];
                        materials[1] = model.materials[3];
                    }
                    else
                    {
                        materials[1] = model.materials[2];
                        materials[0] = model.materials[3];
                    }
                    mesh.materials = materials;
                }
                else mesh.material = model.materials[2];
            }

            shiny = true;
        }
    }


}

[Serializable]
public class PokemonModel
{
    public GameObject model;
    public SkinnedMeshRenderer[] meshes;
    public Material[] materials;
    public Animator animator;

    public PokemonModel(GameObject model, SkinnedMeshRenderer[] meshes, Material[] materials, Animator animator)
    {
        this.model = model;
        this.meshes = meshes;
        this.materials = materials;
        this.animator = animator;
    }
}

public enum Pokemon
{
    Pondeer,
    Mooswamp
}



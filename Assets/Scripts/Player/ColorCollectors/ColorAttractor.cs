using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.ParticleSystemJobs;
public class ColorAttractor : MonoBehaviour
{
    ParticleSystem particlesystem;
    List<ParticleSystem.Particle> particles;
    Transform attractor;
    ColorCollector collector;
    private void Start()
    {
        collector = GameObject.FindGameObjectWithTag("Player").GetComponent<ColorCollector>();
        attractor = GameObject.FindGameObjectWithTag("Attractor").GetComponent<Transform>();
        particlesystem = GetComponent<ParticleSystem>();
        particles = new List<ParticleSystem.Particle>();
        particlesystem.trigger.AddCollider(attractor);
    }
    private void OnParticleTrigger()
    {
        int trigggeredParticles = particlesystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, particles);
        for (int i = 0; i < trigggeredParticles; i++)
        {
            ParticleSystem.Particle particle = particles[i];
            if (particle.startColor == Color.red)
            {
                collector.redCollect();
            }
            if (particle.startColor == Color.green)
            {
                collector.greenCollect();
            }
            if (particle.startColor == Color.blue)
            {
                collector.blueCollect();
            }


            particle.remainingLifetime = 0.1f;
            particles[i] = particle;
        }
        particlesystem.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, particles);
    }
}
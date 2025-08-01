﻿using Client.Main.Content;
using Client.Main.Controllers;
using Client.Main.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;

namespace Client.Main.Objects.Monsters
{
    [NpcInfo(2, "Budge Dragon")]
    public class BudgeDragon : MonsterObject
    {
        private new ILogger _logger = ModelObject.AppLoggerFactory?.CreateLogger<MonsterObject>();

        public BudgeDragon()
        {
            RenderShadow = true;
            Scale = 0.5f;
        }

        public override async Task Load()
        {
            Model = await BMDLoader.Instance.Prepare($"Monster/Monster03.bmd");
            Position = new Vector3(Position.X, Position.Y, Position.Z - 40f);
            await base.Load();
            SetActionSpeed(MonsterActionType.Walk, 0.7f);
        }

        protected override void OnIdle()
        {
            base.OnIdle();
            Vector3 listenerPosition = ((Controls.WalkableWorldControl)World).Walker.Position;
            SoundController.Instance.PlayBufferWithAttenuation("Sound/mBudge1.wav", Position, listenerPosition);
        }

        protected override void OnStartWalk()
        {
            base.OnStartWalk();
            Vector3 listenerPosition = ((Controls.WalkableWorldControl)World).Walker.Position;
            // SoundController.Instance.PlayBufferWithAttenuation("Sound/mBudge1.wav", Position, listenerPosition);
        }

        public override void OnPerformAttack(int attackType = 1)
        {
            base.OnPerformAttack(attackType);
            Vector3 listenerPosition = ((Controls.WalkableWorldControl)World).Walker.Position;
            SoundController.Instance.PlayBufferWithAttenuation("Sound/mBudgeAttack1.wav", Position, listenerPosition);
        }

        public override void OnReceiveDamage()
        {
            base.OnReceiveDamage();
            Vector3 listenerPosition = ((Controls.WalkableWorldControl)World).Walker.Position;
            SoundController.Instance.PlayBufferWithAttenuation("Sound/mBudgeAttack1.wav", Position, listenerPosition); // In C++ it was the same sound as the attack
        }

        public override void OnDeathAnimationStart()
        {
            base.OnDeathAnimationStart();
            Vector3 listenerPosition = ((Controls.WalkableWorldControl)World).Walker.Position;
            SoundController.Instance.PlayBufferWithAttenuation("Sound/mBudgeDie.wav", Position, listenerPosition);
        }
    }
}

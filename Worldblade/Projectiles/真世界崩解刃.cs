using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace Worldblade.Projectiles
{

    public class 真世界崩解刃 : ModProjectile
    {
        // 视觉上的大小
        private float scale = 1.0f; // 修改1.0f可以调整弹射物的大小


        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 1; // 设置弹射物的帧数为11，可以修改这个数字来更改动画帧数，这个的数值为你的spreadsheet 的帧数
        }

        // 设置默认属性
        public override void SetDefaults()
        {
            Projectile.width = 60;  // 弹射物的宽度 （打击 非视觉）
            Projectile.height = 144; // 弹射物的高度 （打击 非视觉）
            Projectile.friendly = true; // 弹射物对玩家是友好的
            Projectile.DamageType = DamageClass.Melee; // 设置弹射物的伤害类型为近战 
            Projectile.hostile = false; // 弹射物对敌人是不友好的
            Projectile.penetrate = 100; // 弹射物可以穿透的敌人数量
            Projectile.timeLeft = 33; // 弹射物的生命周期
            Projectile.damage = 548;  // 弹射物的伤害值
            Projectile.tileCollide = false; // 弹射物不会与瓦片（地面、墙壁等）碰撞

        }

        // 弹射物的AI逻辑
        public override void AI()
        {
            // 增加帧计数器
            Projectile.frameCounter++;

            // 每3刻（游戏的更新单位）更改一次帧
            if (Projectile.frameCounter >= 3)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0; // 如果超出帧数，则重置为第一帧
                }
            }

            // 在弹射物的位置添加灯光
            Vector2 lightPosition = Projectile.position + new Vector2(Projectile.width / 2, 0);
            Lighting.AddLight(lightPosition, 0.8f, 0.8f, 0.8f);

            // 降低弹射物的速度， 速度会递减
            Projectile.velocity *= 0.9f;

        }

        // 绘制弹射物
        public override bool PreDraw(ref Color lightColor)
        {
            // 如果当前帧大于弹射物帧数的一半，则降低透明度
            if (Projectile.frame > Main.projFrames[Projectile.type] / 2)
            {
                lightColor = lightColor * 0.4f;
            }

            // 根据弹射物的移动方向设置效果
            SpriteEffects effects = SpriteEffects.None;
            if (Projectile.velocity.X < 0)
            {
                effects = SpriteEffects.FlipHorizontally; // 如果弹射物向左移动，则翻转图像
            }

            // 获取弹射物的纹理
            Texture2D texture = ModContent.Request<Texture2D>(Texture).Value;

            // 绘制弹射物
            Main.EntitySpriteDraw(
                texture,
                new Vector2(Projectile.Center.X - Main.screenPosition.X, Projectile.Center.Y - Main.screenPosition.Y),
                new Rectangle(0, Projectile.frame * texture.Height / Main.projFrames[Projectile.type], texture.Width, texture.Height / Main.projFrames[Projectile.type]),
                lightColor,
                Projectile.rotation,
                new Vector2(texture.Width / 2, texture.Height / Main.projFrames[Projectile.type] / 2),
                scale,
                effects,
                0
            );

            return false; // 返回false表示不使用默认的绘制方法
        }
        
    }
    
}
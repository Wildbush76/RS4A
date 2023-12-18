﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RS4A.Items
{
    public class MicroShark : ModItem
    {
        public override string Texture => "Terraria/Images/Item_" + ItemID.Minishark;
        public override void SetDefaults()
        {
            Item.DefaultToRangedWeapon(ModContent.ProjectileType<Projectiles.ShootYourselfBullets>(),AmmoID.Bullet,20,50,true);
            Item.damage = 2;
           
        }
        
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source,position,velocity, ModContent.ProjectileType<Projectiles.ShootYourselfBullets>(), damage,knockback);
            return false;
        }
        
    }
}
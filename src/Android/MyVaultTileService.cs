﻿using Android.App;
using Android.Content;
using Android.Service.QuickSettings;
using Java.Lang;

namespace Bit.Android
{
    [Service(Permission = global::Android.Manifest.Permission.BindQuickSettingsTile,
        Label = "@string/MyVault", Icon = "@drawable/shield")]
    [IntentFilter(new string[] { ActionQsTile })]
    public class MyVaultTileService : TileService
    {
        public override void OnTileAdded()
        {
            base.OnTileAdded();
        }

        public override void OnStartListening()
        {
            base.OnStartListening();
        }

        public override void OnStopListening()
        {
            base.OnStopListening();
        }

        public override void OnTileRemoved()
        {
            base.OnTileRemoved();
        }

        public override void OnClick()
        {
            base.OnClick();

            if(IsLocked)
            {
                UnlockAndRun(new Runnable(() =>
                {
                    LaunchMyVault();
                }));
            }
            else
            {
                LaunchMyVault();
            }
        }

        private void LaunchMyVault()
        {
            var intent = new Intent(this, typeof(SplashActivity));
            intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.SingleTop | ActivityFlags.ClearTop);
            intent.PutExtra("myVaultTile", true);
            StartActivityAndCollapse(intent);
        }
    }
}
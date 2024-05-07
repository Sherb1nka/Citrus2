import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { VgApiService, VgCoreModule } from "@videogular/ngx-videogular/core";
import { VgControlsModule } from "@videogular/ngx-videogular/controls";
import { VgOverlayPlayModule } from "@videogular/ngx-videogular/overlay-play";
import { VgBufferingModule } from "@videogular/ngx-videogular/buffering";

@Component({
  selector: 'ctrs-videoplayer',
  standalone: true,
  imports: [
    CommonModule,
    VgCoreModule,
    VgControlsModule,
    VgOverlayPlayModule,
    VgBufferingModule  
  ],
  templateUrl: './videoplayer.component.html',
  styleUrl: './videoplayer.component.scss'
})
export class VideoplayerComponent {
  preload: string = 'auto';
  api: VgApiService = new VgApiService;

  @Input()
  videoFileName: string = 'lectionTest.mp4';
  
  onPlayerReady(source: VgApiService) {
    this.api = source;
    console.log("onPlayerReady");
    this.api.getDefaultMedia().subscriptions.loadedMetadata.subscribe(
      this.autoplay.bind(this)
    )
  }
  
  autoplay() {
    console.log("play");
    this.api.play();
  }
  
}

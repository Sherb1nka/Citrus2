import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { VgApiService, VgCoreModule } from "@videogular/ngx-videogular/core";
import { VgControlsModule } from "@videogular/ngx-videogular/controls";
import { VgOverlayPlayModule } from "@videogular/ngx-videogular/overlay-play";
import { VgBufferingModule } from "@videogular/ngx-videogular/buffering";
import { TimeCode } from '../shared/timecode';

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

	@Input()
	set timeCodeToGo(timeCodeToGo: TimeCode) {
		this.playFromTimeCode(timeCodeToGo);
	}

	onPlayerReady(source: VgApiService): void {
		this.api = source;
		console.log("onPlayerReady");
		this.api.getDefaultMedia().subscriptions.loadedMetadata.subscribe(
			this.autoplay.bind(this)
		)
	}

	autoplay(): void {
		console.log("play");
		this.api.play();
	}

	playFromTimeCode(timecode: TimeCode): void {
		this.api.pause();
		this.api.seekTime(timecode.totalSeconds);
		this.api.play();
	}
}

import { Component, Input, OnInit, Output } from '@angular/core';
import { VideoplayerComponent } from '../videoplayer/videoplayer.component';
import { PresentationComponent } from '../presentation/presentation.component';
import { CommentariesComponent } from "../commentaries/commentaries.component";
import { SuggestionsComponent } from "../suggestions/suggestions.component";
import { PresentationApiClient, PresentationModel, PresentationSheetModel, VideoApiClient, VideoModel } from '../../services/ApiClient.nswag';
import { NgIf } from '@angular/common';
import { Router } from '@angular/router';
import { TimeCode } from '../shared/timecode';

@Component({
    selector: 'ctrs-media-window',
    standalone: true,
    templateUrl: './media-window.component.html',
    styleUrl: './media-window.component.scss',
    imports: [
        VideoplayerComponent,
        PresentationComponent,
        CommentariesComponent,
        SuggestionsComponent,
        NgIf,
    ]
})
export class MediaWindowComponent {
    private _video: VideoModel = new VideoModel();
    private _presentation: PresentationModel = new PresentationModel();
    private _currentTimeCode: TimeCode = new TimeCode();
    
    constructor(private readonly _videoApiClient: VideoApiClient,
        private readonly _presentationApiClient: PresentationApiClient,
        private readonly _router: Router
    ) {
        this._videoApiClient.getVideoById(4).toPromise()
        .then(v => {
            this.video = v as VideoModel;
            this._presentationApiClient.getPresentationById(this.video.presentations?.at(0)?.id)
            .toPromise()
            .then(p => {
                this._presentation = p as PresentationModel;
            });
        });
    }    

    get currentTimeCode(): TimeCode {
        return this._currentTimeCode;
    }

    get video(): VideoModel {
        return this._video;
    }
    
    set video(video: VideoModel) {
        this._video = video;
    }
    
    get isPresentationAvailable(): boolean {
        return !!this._presentation;
    }
    
    get presentation(): PresentationModel | undefined {
        return this._presentation;
    }
    
    set presentation(value: PresentationModel) {
        this._presentation = value;
    }
    
    get currentVideoPresentationSheets(): PresentationSheetModel[] {
        return this._presentation.presentationSheets as PresentationSheetModel[];
    }
    
    openPresentationMaker(): void {
        this._router.navigate(['presentationmaker'], { state: { videoId: this.video.id } });
    }

    handleSlideClick(timeCodeToGo: TimeCode) {
        this._currentTimeCode = timeCodeToGo;
    }
    
}

import { Component } from '@angular/core';
import { VideoplayerComponent } from '../videoplayer/videoplayer.component';
import { PresentationComponent } from '../presentation/presentation.component';
import { CommentariesComponent } from "../commentaries/commentaries.component";
import { SuggestionsComponent } from "../suggestions/suggestions.component";

@Component({
    selector: 'ctrs-media-window',
    standalone: true,
    templateUrl: './media-window.component.html',
    styleUrl: './media-window.component.scss',
    imports: [
        VideoplayerComponent,
        PresentationComponent,
        CommentariesComponent,
        SuggestionsComponent
    ]
})
export class MediaWindowComponent {

}

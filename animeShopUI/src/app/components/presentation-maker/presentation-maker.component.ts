import { Component, OnInit, Output } from '@angular/core';
import { PresentationSheetComponent } from "./presentation-sheet/presentation-sheet.component";
import { PresentationSheetlistComponent } from "./presentation-sheetlist/presentation-sheetlist.component";
import { PresentationApiClient, PresentationModel, PresentationSheetModel } from '../../services/ApiClient.nswag';
import { Navigation, Router } from '@angular/router';

@Component({
    selector: 'ctrs-presentation-maker',
    standalone: true,
    templateUrl: './presentation-maker.component.html',
    styleUrl: './presentation-maker.component.scss',
    imports: [PresentationSheetComponent, PresentationSheetlistComponent]
})
export class PresentationMakerComponent {
    private _presentation: PresentationModel = new PresentationModel;
    private _imageUrls: string[] = [];

    constructor(private _presentationApiClient: PresentationApiClient,
                private readonly _router: Router) {

        let nav: Navigation = this._router.getCurrentNavigation() as Navigation;
        if (nav.extras && nav.extras.state && nav.extras.state["videoId"]) {
            this.presentation.videoId = nav.extras.state["videoId"] as number;
        }
    }

    get presentation(): PresentationModel {
        return this._presentation;
    }

    set presentation(presentation: PresentationModel) {
        this._presentation = presentation;
    }

    get presentationSheetsList(): PresentationSheetModel[] {
        return this.presentation.presentationSheets ?? [];
    }

    handleSlideSave(presentationSheet: PresentationSheetModel): void
    {
        if (!this.presentation.presentationSheets) {
            this._presentation.presentationSheets = [];
        }
        this._presentation.presentationSheets?.push(presentationSheet);
        this.savePresentation();
    }

    savePresentation(): void {
        this._presentationApiClient.addPresentation(this.presentation)
            .toPromise()
            .then((p) => {
                this.presentation = p as PresentationModel;
                console.log("presentation saved");
            });
    }
}

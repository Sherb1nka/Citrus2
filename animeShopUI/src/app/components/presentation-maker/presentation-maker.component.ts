import { Component, OnInit, Output } from '@angular/core';
import { PresentationSheetComponent } from "./presentation-sheet/presentation-sheet.component";
import { PresentationSheetlistComponent } from "./presentation-sheetlist/presentation-sheetlist.component";
import { PresentationApiClient, PresentationDTO, PresentationSheetDTO } from '../../services/ApiClient.nswag';

@Component({
    selector: 'ctrs-presentation-maker',
    standalone: true,
    templateUrl: './presentation-maker.component.html',
    styleUrl: './presentation-maker.component.scss',
    imports: [PresentationSheetComponent, PresentationSheetlistComponent]
})
export class PresentationMakerComponent {
    private _presentation: PresentationDTO = new PresentationDTO;
    private _imageUrls: string[] = [];

    constructor(private _presentationApiClient: PresentationApiClient){
    }

    get presentation(): PresentationDTO {
        return this._presentation;
    }

    set presentation(presentation: PresentationDTO) {
        this._presentation = presentation;
    }

    get presentationSheetsList(): PresentationSheetDTO[] {
        return this.presentation.presentationSheets ?? [];
    }

    handleSlideSave(presentationSheet: PresentationSheetDTO): void
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
                this.presentation = p as PresentationDTO;
                console.log("presentation saved");
            });
    }
}

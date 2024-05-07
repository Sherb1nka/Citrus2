import { Component } from '@angular/core';
import { PresentationSheetComponent } from "./presentation-sheet/presentation-sheet.component";
import { PresentationSheetlistComponent } from "./presentation-sheetlist/presentation-sheetlist.component";

@Component({
    selector: 'ctrs-presentation-maker',
    standalone: true,
    templateUrl: './presentation-maker.component.html',
    styleUrl: './presentation-maker.component.scss',
    imports: [PresentationSheetComponent, PresentationSheetlistComponent]
})
export class PresentationMakerComponent {

    private _imageUrls: string[] = [];

    get imageUrls() {
        return this._imageUrls;
    }
    
    handleSlideSave(imageUrl: string) {
        this._imageUrls.push(imageUrl);
    }
}

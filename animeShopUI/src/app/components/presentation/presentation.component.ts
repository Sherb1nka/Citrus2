import { NgFor } from '@angular/common';
import { Component, Input } from '@angular/core';
import { PresentationSheetModel } from '../../services/ApiClient.nswag';

@Component({
	selector: 'ctrs-presentation',
	standalone: true,
	imports: [NgFor],
	templateUrl: './presentation.component.html',
	styleUrl: './presentation.component.scss'
})
export class PresentationComponent {
	private _presentationSheets: PresentationSheetModel[] = [];

	get presentationSheets(): PresentationSheetModel[] {
		return this._presentationSheets;
	}

	@Input()
	set presentationSheets(presentationSheets: PresentationSheetModel[]) {	
		this._presentationSheets = presentationSheets;
	}
}

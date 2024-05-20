import { Component, Output, EventEmitter, OnInit, Input} from '@angular/core';

// Import all Froala Editor plugins.
import 'froala-editor/js/plugins.pkgd.min.js';

// Import a single Froala Editor plugin.
import 'froala-editor/js/plugins/align.min.js';

// Import a Froala Editor language file.
import 'froala-editor/js/languages/de.js';

// Import a third-party plugin.
import 'froala-editor/js/third_party/font_awesome.min';
import 'froala-editor/js/third_party/image_tui.min';
import 'froala-editor/js/third_party/spell_checker.min';
import 'froala-editor/js/third_party/embedly.min';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { EDIT_SLIDE } from '../constants';
import html2canvas from 'html2canvas';
import { PresentationSheetModel } from '../../../services/ApiClient.nswag';
import { FormsModule } from '@angular/forms';

@Component({
	selector: 'ctrs-presentation-sheet',
	standalone: true,
	imports: [
		FroalaEditorModule,
		FroalaViewModule,
		FormsModule
	],
	templateUrl: './presentation-sheet.component.html',
	styleUrl: './presentation-sheet.component.scss'
})
export class PresentationSheetComponent {	
	private _presentationSheet: PresentationSheetModel = new PresentationSheetModel;
	private _maxLength: string = "";
	
	editorContent: string = EDIT_SLIDE;
	
	hours: number = 0;
	minutes: number = 0;
	seconds: number = 0;

	get presentationSheet(): PresentationSheetModel {
		return this._presentationSheet;
	}

	set presentationSheet(presentationSheet: PresentationSheetModel) {
		this._presentationSheet = presentationSheet;
	}
	
	@Output()
	onSlideSave = new EventEmitter<PresentationSheetModel>();
	
	get maxLength(): string {
		return this._maxLength;
	}

	@Input()
	set maxLength(length: string) {
		this._maxLength = length;
	}

	makeSnapshot() {
		html2canvas(document.querySelector("#capture") as HTMLElement).then((canvas) => {
			let imageUrl = canvas.toDataURL("image/png");
			this._presentationSheet.imgUrl = canvas.toDataURL("image.png");
			this._presentationSheet.htmlText = this.editorContent;
			this._presentationSheet.timeCodeHours = this.hours;
			this._presentationSheet.timeCodeMinutes = this.hours;
			this._presentationSheet.timeCodeSeconds = this.seconds;
			this.saveSlide();
		});
	}

	saveSlide() {
		this.onSlideSave.emit(this.presentationSheet)
	}			
}

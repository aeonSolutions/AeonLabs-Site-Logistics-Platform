gLevel = $level;
    }

    /** Encode charset when charset is not utf-8 */
    protected function _convertString($string)
    {
        $charset = strtolower($this->getCharset());
        if (!in_array($charset, array('utf-8', 'iso-8859-1', 'iso-8859-15', ''))) {
            // mb_convert_encoding must be the first one to check, since iconv cannot convert some words.
            if (function_exists('mb_convert_encoding')) {
                $string = mb_convert_encoding($string, $charset, 'utf-8');
            } elseif (function_exists('iconv')) {
                $string = iconv('utf-8//TRANSLIT//IGNORE', $charset, $string);
            } else {
                throw new Swift_SwiftException('No suitabl
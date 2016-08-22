#!/usr/bin/perl -w
################################################################################
# This script shows how to retrieve some values from the
#    Gembird energenie Power Meter EGM-PWM-LAN
# via the web interface.
################################################################################

use strict;
use warnings;
use LWP::UserAgent;

my ($Value, $Browser, $Response, $Result, @Records, $Record, $Idx);
my @Values = (
    'V', 'Voltage',  10.0, 'V',        # factors are take from script: eg.js
    'I', 'Current', 100.0, 'A',
    'P', 'Power',   466.0, 'W',
    'E', 'Energie',  25.6, 'Wh');
my $IP         = '192.168.0.101';
my $Password = '1';
my $Msg         = 'Impossible to login - there is an active session with this device at this moment.';
 
$Browser  = LWP::UserAgent->new;
$Response = $Browser->post ('http://' . $IP . '/login.html', ['pw' => $Password, 'submit'],);

die $Response->status_line if (!$Response->is_success);    # check success
die $Msg if (index ($Response->content, $Msg) > 0);        # check blocking

$Result = $Response->content;
$Result =~ s/\s+//g;    # aweful html code - do some cleaning
@Records = split (/;/, $Result);    # split into seperate lines

foreach $Record (@Records)
{    if (!index ($Record, 'var'))    # if line starts with 'var'
    {    $Record = substr ($Record, 3);    # take everything after 'var'
        
        for ($Idx = 0; $Idx < scalar (@Values); $Idx += 4)
        {    if (!index ($Record, $Values[$Idx] . '='))    # starts with variable & '='
            {    $Value = substr ($Record, length ($Values[$Idx]) + 1);
                
                printf "%-7s: %s %s\n",
                    $Values[$Idx + 1], $Value / $Values[$Idx + 2], $Values[$Idx + 3];
            }
        }
    }
}

# Use the following line to release the session! It should bot be used if you do
# a looping via the previous code.
$Browser->get ('http://' . $IP . '/login.html');